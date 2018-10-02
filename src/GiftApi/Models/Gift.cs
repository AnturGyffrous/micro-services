using System;

namespace GiftApi.Models
{
    public class Gift
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}