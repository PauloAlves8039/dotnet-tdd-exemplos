namespace Dotnet.Empresa
{
    public class CalculadoraDeSalario
    {
        public double CalcularSalario(Funcionario funcionario)
        {
            switch (funcionario.Cargo)
            {
                case Cargo.DESENVOLVEDOR:
                    return CalcularSalarioDesenvolvedor(funcionario.Salario);
                case Cargo.DBA:
                case Cargo.TESTADOR:
                    return CalcularSalarioDBATestador(funcionario.Salario, funcionario.Cargo);
                default:
                    throw new ArgumentException("Cargo inválido");
            }
        }

        private double CalcularSalarioDesenvolvedor(double salario)
        {
            var limiteSalarioDesenvolvedor = 3000.0;
            var taxaDescontoDesenvolvedorAcimaDoLimite = 0.2;
            var taxaDescontoDesenvolvedorAbaixoDoLimite = 0.1;

            var desconto = salario > limiteSalarioDesenvolvedor ? 
                                        taxaDescontoDesenvolvedorAcimaDoLimite : 
                                        taxaDescontoDesenvolvedorAbaixoDoLimite;

            return salario * (1 - desconto);
        }

        private double CalcularSalarioDBATestador(double salario, Cargo cargo)
        {
            var limiteSalarioDBATestador = 2500.0;
            var taxaDescontoDBAAcimaDoLimite = 0.25;
            var taxaDescontoDBAAbaixoDoLimite = 0.15;
            var taxaDescontoTestadorAcimaDoLimite = 0.15;
            var taxaDescontoTestadorAbaixoDoLimite = 0.10;

            var desconto = 0.0;

            if (cargo == Cargo.DBA)
            {
                desconto = salario > limiteSalarioDBATestador ? taxaDescontoDBAAcimaDoLimite : taxaDescontoDBAAbaixoDoLimite;
            }
            else if (cargo == Cargo.TESTADOR)
            {
                desconto = salario > limiteSalarioDBATestador ? taxaDescontoTestadorAcimaDoLimite : taxaDescontoTestadorAbaixoDoLimite;
            }

            return salario * (1 - desconto);
        }

    }
}
