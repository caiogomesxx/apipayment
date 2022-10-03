using Desafio.Infra.Repositories;
using Xunit;

namespace Desafio.Tests
{
    public class VendaTest
    {
        private VendaRepository vendaRepository;
        public VendaTest() 
        {
            ve         }
        [Fact]
        public void updateAnaliseCreditos()
        {
            try
            {
                Vendar Ac = new AnaliseCreditos(IDOrganizacao, dbAccess, dbCorp, dbCapys);
                Ac.updateAnaliseCreditos();

                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
