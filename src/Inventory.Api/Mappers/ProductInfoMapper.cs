﻿using Inventory.Abstraction.Dto;
using Inventory.Api.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ProductInfoMapper
    {
        public static ProductInfoDto MapToDto(ProductInfo productInfo)
        {
            return new ProductInfoDto
            {
                Upc = productInfo.Upc,
                Brand = productInfo.Brand,
                Name = productInfo.Name,
                Description = productInfo.Description,
                ExpirationLocation = productInfo.ExpirationLocation,
                OunceWeight = productInfo.OunceWeight,
                RequiresBox = productInfo.RequiresBox,
                RequiresBubbleWrap = productInfo.RequiresBubbleWrap,
                RequiresPadding = productInfo.RequiresPadding
            };
        }

        public static IEnumerable<ProductInfoDto> MapToDto(IEnumerable<ProductInfo> productInfos)
        {
            var productInfoDtos = productInfos.Select(x => MapToDto(x));
            return productInfoDtos;
        }
    }
}
