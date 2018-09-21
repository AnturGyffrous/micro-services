using System.Collections.Generic;

using GiftApi.Data.Models;

namespace GiftApi.Infrastructure
{
    public interface IGiftRepository
    {
        IEnumerable<GiftDto> Gifts { get; }
    }
}
