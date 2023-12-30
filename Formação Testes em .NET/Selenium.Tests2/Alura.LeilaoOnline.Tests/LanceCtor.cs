using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.Tests;

public class LanceCtor
{
    [Fact]
    public void LancaArgumentExceptionDadoValorNegativo()
    {
        //Arranje
        var valorNegativo = -100;

        //Assert
        Assert.Throws<ArgumentException>(
            //Act
            () => new Lance(null, valorNegativo)
        );
    }
}
