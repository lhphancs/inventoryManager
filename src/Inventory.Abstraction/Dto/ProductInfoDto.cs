﻿namespace Inventory.Abstraction.Dto
{
    public class ProductInfoDto
    {
        public string Upc { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpirationLocation { get; set; }
        public int OunceWeight { get; set; }
        public bool RequiresPadding { get; set; }
        public bool RequiresBubbleWrap { get; set; }
        public bool RequiresBox { get; set; }
    }
}
