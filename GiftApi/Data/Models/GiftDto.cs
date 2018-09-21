using System;

namespace GiftApi.Data.Models
{
    public class GiftDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastModified { get; set; }
    }
}
