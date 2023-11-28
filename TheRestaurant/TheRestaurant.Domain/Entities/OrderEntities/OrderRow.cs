﻿using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Domain.Entities.OrderEntities
{
    public class OrderRow
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public ICollection<Product> MenuItem { get; set; }

        public OrderRow()
        {
            
        }
    }
}
