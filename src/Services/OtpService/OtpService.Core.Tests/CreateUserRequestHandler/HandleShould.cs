// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using OtpService.Core.AggregateModel.UserAggregate.Commands;

namespace OtpService.Core.Tests.CreateUserRequestHandler;

using CreateUserRequestHandler = OtpService.Core.AggregateModel.UserAggregate.Commands.CreateUserRequestHandler;

public class HandleShould
{
    [Fact]
    public void DoSomething_GivenSomething()
    {
        // ARRANGE

        CreateUserRequestHandler v = new CreateUserRequestHandler(null, null);
        
        // ACT

        // ASSERT

    }

}


