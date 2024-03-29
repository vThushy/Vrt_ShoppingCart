﻿using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IOrderDetailsRepository
    {
        OrderDetail AddOrderLine(OrderDetail order);

        List<OrderDetail> GetOrderLines(int orderId);
    }
}
