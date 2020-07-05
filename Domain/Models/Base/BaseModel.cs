using Commons.Enums;
using System;

namespace Domain.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        public EStatusErased Erased { get; set; }
    }
}
