using System.Collections.Generic;

namespace GiftApi.Models
{
    public class ListResponse<T> : Response
    {
        public T[] Results { get; set; }

        public long Count { get; set; }

        public long Total { get; set; }
    }
}
