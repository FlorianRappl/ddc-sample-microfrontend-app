﻿using System.Collections.Generic;
using System.Linq;

namespace ddc_sample_app.Module.Discover
{
    public class InMemoryGameRepository : IGameRepository
    {
        private readonly List<Game> _games = new()
        {
            new Game { Id = 1, Name = "Catan", Price = 45.00m, Image = "https://i.imgur.com/oxtSRMPm.png" },
            new Game { Id = 2, Name = "Carcassonne", Price = 35.00m, Image = "https://i.imgur.com/Fxis0ylm.png" },
            new Game { Id = 3, Name = "Pandemic", Price = 36.99m, Image = "https://i.imgur.com/o1uJzsjm.png" },
            new Game { Id = 4, Name = "Ticket To Ride", Price = 32.99m, Image = "https://i.imgur.com/Y0ygkMMm.png" },
            new Game { Id = 5, Name = "Monopoly", Price = 36.99m, Image = "https://i.imgur.com/6Scpulwm.png" },
            new Game { Id = 6, Name = "Uno", Price = 7.99m, Image = "https://i.imgur.com/3QGQtsGm.png" },
            new Game { Id = 7, Name = "Splendor", Price = 34.99m, Image = "https://i.imgur.com/WL7glE6m.png" },
            new Game { Id = 8, Name = "Everdell", Price = 62.99m, Image = "https://i.imgur.com/LNLvNu1m.png" },
            new Game { Id = 9, Name = "Wingspan", Price = 43.99m, Image = "https://i.imgur.com/IDaRMb9m.png" },
            new Game { Id = 10, Name = "Terraforming Mars", Price = 49.99m, Image = "https://i.imgur.com/Bqaz3NQm.png" },
            new Game { Id = 11, Name = "Paleo", Price = 41.99m, Image = "https://i.imgur.com/qPxK9yQm.png" },
        };

        public IEnumerable<Game> GetAll() => _games;
        public Game GetBy(int id) => _games.SingleOrDefault(g => g.Id.Equals(id));
    }
}
