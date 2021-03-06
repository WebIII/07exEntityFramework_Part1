﻿using System.Collections.Generic;
using System.Linq;
using System;

namespace SportsStore.Models
{
    public class Cart
    {
        #region Properties
        private readonly IList<CartLine> _lines = new List<CartLine>();
        public IEnumerable<CartLine> CartLines => _lines.AsEnumerable();
        public int NumberOfItems => _lines.Count();
        public decimal TotalValue => _lines.Sum(l => l.Product.Price * l.Quantity);
        #endregion

        #region Methods
        public void AddLine(Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveLine(Product product)
        {
            CartLine line = _lines.SingleOrDefault(l => l.Product.Equals(product));
            if (line != null)
                _lines.Remove(line);
        }

        public void Clear()
        {
            _lines.Clear();
        }

        #endregion
    }
}