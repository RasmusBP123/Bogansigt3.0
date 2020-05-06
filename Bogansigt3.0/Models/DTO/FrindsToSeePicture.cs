using BogAnsigt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bogansigt3._0.Models.DTO
{
    public class FrindsToSeePicture
    {
        public User Friend { get; set; }
        public Boolean CanSeePicture { get; set; }
    }
}
