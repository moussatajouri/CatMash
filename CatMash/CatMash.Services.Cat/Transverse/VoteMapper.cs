using CatMash.Services.Cat.DataAccess;
using CatMash.Services.Cat.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services.Cat.Transverse
{
    public static class VoteMapper
    {
        public static TVote Map(VoteRequest voteRequest)
        {
            if (voteRequest == null)
            {
                return null;
            }

            return new TVote
            {
                LostCatId = voteRequest.LostId,
                WinCatId = voteRequest.WinId,
                CreationDate = DateTime.Now
            };
        }
    }
}
