using System;
using System.Threading;
using System.Threading.Tasks;
using GiftApi.MediatRRequests;
using GiftApi.Models;
using MediatR;

namespace GiftApi.Mediator.Handlers
{
    public class GetGiftHandler : IRequestHandler<GetGift, Gift>
    {
        public Task<Gift> Handle(GetGift request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Parse("a82aa4b1-45bb-4ecb-a5aa-50de618f2e1d"))
            {
                return Task.FromResult(new Gift { Id = request.Id, Name = "Amazon.co.uk Gift Card", Slug = "amazon-uk" });
            }

            return Task.FromResult((Gift)null);
        }
    }
}