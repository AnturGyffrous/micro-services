using System.Collections.Generic;

namespace GiftApi.Models
{
    public abstract class Response
    {
        public ResponseError[] ResponseErrors { get; set; }
    }
}
