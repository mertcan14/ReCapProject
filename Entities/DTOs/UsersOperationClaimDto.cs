﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UsersOperationClaimDto : IDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string[] ClaimName { get; set; }
    }
}
