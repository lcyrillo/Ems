using CS.Ems.Domain.Entities;
using GenFu;
using System.Collections.Generic;

namespace CS.Ems.Profile.Api.Unity.Tests.Factory
{
    public class TechnicalProfileFactory
    {
        public TechnicalProfileFactory()
        {
            A.Configure<TechnicalProfile>()
                .Fill(x => x.Id).WithinRange(1, 10)
                .Fill(x => x.Name).AsLoremIpsumWords(10)
                .Fill(x => x.Description).AsLoremIpsumWords(10);

            A.New<TechnicalProfile>();
        }
    }
}
