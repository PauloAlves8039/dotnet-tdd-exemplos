namespace Dotnet.Empresa.Tests
{
    public class CalculadoraDeSalarioTest
    {
        CalculadoraDeSalario calculadoraDeSalario = new CalculadoraDeSalario();

        [Fact]
        public void CalculadoraDeSalario_DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite()
        {
            var desenvolvedor = new Funcionario("Paulo", 1500.0, Cargo.DESENVOLVEDOR);

            var salario = calculadoraDeSalario.CalcularSalario(desenvolvedor);

            var salarioEsperado = 1350.0;

            Assert.Equal(salarioEsperado, salario);
        }

        [Fact]
        public void CalculadoraDeSalario_DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite()
        {
            var desenvolvedor = new Funcionario("Paulo", 4000.0, Cargo.DESENVOLVEDOR);

            var salario = calculadoraDeSalario.CalcularSalario(desenvolvedor);

            var salarioEsperado = 3200.0;

            Assert.Equal(salarioEsperado, salario);
        }

        [Fact]
        public void CalculadoraDeSalario_DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite()
        {
            var dba = new Funcionario("Paulo", 500.0, Cargo.DBA);

            var salario = calculadoraDeSalario.CalcularSalario(dba);

            var salarioEsperado = 425.0;

            Assert.Equal(salarioEsperado, salario);
        }

        [Fact]
        public void CalculadoraDeSalario_DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite()
        {
            var dba = new Funcionario("Paulo", 3000.0, Cargo.DBA);

            var salario = calculadoraDeSalario.CalcularSalario(dba);

            var salarioEsperado = 2250.0;

            Assert.Equal(salarioEsperado, salario);
        }

        [Fact]
        public void CalculadoraDeSalario_DeveCalcularSalarioParaTestadoresComSalarioAbaixoDoLimite()
        {
            var testador = new Funcionario("Paulo", 2000.0, Cargo.TESTADOR);

            var salario = calculadoraDeSalario.CalcularSalario(testador);

            var salarioEsperado = 1800.0;

            Assert.Equal(salarioEsperado, salario);
        }

        [Fact]
        public void CalculadoraDeSalario_DeveCalcularSalarioParaTestadoresComSalarioAcimaDoLimite()
        {
            var testador = new Funcionario("Paulo", 3000.0, Cargo.TESTADOR);

            var salario = calculadoraDeSalario.CalcularSalario(testador);

            var salarioEsperado = 2550.0;

            Assert.Equal(salarioEsperado, salario);
        }
    }
}