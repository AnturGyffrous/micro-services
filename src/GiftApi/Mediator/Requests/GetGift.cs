using System;

using GiftApi.Models;

using MediatR;

namespace GiftApi.MediatRRequests
{
    public class GetGift : IRequest<Gift>
    {
        public Guid Id { get; set; }
    }
}
