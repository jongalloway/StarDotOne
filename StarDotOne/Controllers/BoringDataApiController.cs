using StarDotOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StarDotOne.Controllers
{
    public class BoringDataApiController : ApiController
    {
        static Random rng = new Random(Guid.NewGuid().GetHashCode());

        public IEnumerable<BoringData> GetBoringData()
        {
            return GetLotsOfBoringData(100);
        }

        private IEnumerable<BoringData> GetLotsOfBoringData(int quantity)
        {
            byte[] buf1 = new byte[10000];
            byte[] buf2 = new byte[64];


            for (int i = 1; i < quantity; i++)
            {
                rng.NextBytes(buf1);
                rng.NextBytes(buf2);

                yield return new BoringData
                {
                    Id  = i,
                    DataBytes = buf1,
                    DataDate = DateTime.UtcNow,
                    DataLong = BitConverter.ToInt64(buf2,0)
                };
            }
        }
    }
}