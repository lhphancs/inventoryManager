﻿using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ShelfProductMapper
    {
        public static ShelfProductDto MapToDto(ShelfProduct shelfProduct)
        {
            if (shelfProduct == null)
            {
                return null;
            }

            return new ShelfProductDto
            {
                Id = shelfProduct.Id,
                ProductId = shelfProduct.ProductId,
                Row = shelfProduct.Row,
                Position = shelfProduct.Position,
                Product = ProductMapper.MapToDto(shelfProduct.Product)
            };
        }
        public static IEnumerable<ShelfProductDto> MapToDto(IEnumerable<ShelfProduct> shelfProducts)
        {
            var shelfLocationDtos = shelfProducts.Select(x => MapToDto(x));
            return shelfLocationDtos;
        }
    }
}
