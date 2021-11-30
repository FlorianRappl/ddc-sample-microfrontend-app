﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Threading.Tasks;

namespace ddc_sample_app.Shared
{
    public class DynamicRouter : IComponent, IHandleAfterRender, IDisposable
    {
        private RenderHandle _renderHandle;
        private bool _navigationInterceptionEnabled;
        private string _location;

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public INavigationInterception NavigationInterception { get; set; }
        [Inject] public RouteManager RouteManager { get; set; }

        [Parameter] public RenderFragment NotFound { get; set; }
        [Parameter] public RenderFragment<RouteData> Found { get; set; }

        // Make sure we can implement the IComponent interface
        public void Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
            _location = NavigationManager.Uri;
            NavigationManager.LocationChanged += HandleLocationChanged;
        }

        // Make sure we can implement the IComponent interface
        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            _ = Found ?? throw new InvalidOperationException(
                $"The {nameof(DynamicRouter)} component requires a value for the parameter {nameof(Found)}.");
            _ = NotFound ?? throw new InvalidOperationException(
                $"The {nameof(DynamicRouter)} component requires a value for the parameter {nameof(NotFound)}.");

            RouteManager.Initialize();
            Refresh();

            return Task.CompletedTask;
        }

        //Set up navigation interception
        public Task OnAfterRenderAsync()
        {
            if (_navigationInterceptionEnabled) return Task.CompletedTask;

            _navigationInterceptionEnabled = true;
            return NavigationInterception.EnableNavigationInterceptionAsync();
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= HandleLocationChanged;
            GC.SuppressFinalize(this);
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs args)
        {
            _location = args.Location;
            Refresh();
        }

        private void Refresh()
        {
            var relativeUri = NavigationManager.ToBaseRelativePath(_location);

            var (segments, parameters) = UriParser.Parse(relativeUri);
            var (isMatch, matchedRoute) = RouteManager.Match(segments);

            var routeData = new RouteData(matchedRoute.Handler, parameters);
            _renderHandle.Render(isMatch ? Found(routeData) : NotFound);
        }
    }
}
