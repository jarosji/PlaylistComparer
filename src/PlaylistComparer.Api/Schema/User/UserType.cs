using HotChocolate.Types;
using PlaylistComparer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistComparer.Api.Schema.User
{
    public class UserType : ObjectType<UserModel>
    {
        protected override void Configure(IObjectTypeDescriptor<UserModel> descriptor)
        {
           
        }
    }
}
