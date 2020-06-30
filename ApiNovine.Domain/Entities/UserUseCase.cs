﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Domain.Entities
{
    public class UserUseCase:Entity
    {
       
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual User User { get; set; }
    
    }
}
