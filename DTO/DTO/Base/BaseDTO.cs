using Commons.Enums;
using System;

namespace DTO.DTO.Base
{
    public class BaseDTO
    {
        public int Id { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset LastUpdate { get; set; }

        public EStatusErased Erased { get; set; }
    }
}
