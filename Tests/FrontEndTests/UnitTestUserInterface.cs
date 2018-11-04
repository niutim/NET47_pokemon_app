using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonFrontEnd.Controls;
using PokemonShared.Models;
using System.Windows.Controls;

namespace FrontEndTests
{
    [TestClass]
    public class UnitTestUserInterface
    {
        [TestMethod]
        public void ListClassesBehaviorTest()
        {
            ListClasses listClasses = new ListClasses();
            listClasses.ListClassesName = new string[] { "Fire", "Water" };
            StackPanel stkPnl = (listClasses as UserControl).Content as StackPanel;
            if(stkPnl!=null)
            {
                Assert.IsTrue(stkPnl.Children.Count == 2);
            }
        }

        [TestMethod]
        public void ListWeaknessesBehaviorTest()
        {
            ListWeaknesses listWeaknesses = new ListWeaknesses();
            listWeaknesses.ListWeaknessesObject = new Weakness[] { new Weakness("Fire", 0.5m), new Weakness("Earth", 1m), new Weakness("Water", 2m) };
            StackPanel stkPnl = (listWeaknesses as UserControl).Content as StackPanel;
            if (stkPnl != null)
            {
                Assert.IsTrue(stkPnl.Children.Count == 3);
            }
        }

        [TestMethod]
        public void ListCharacterWithLinkBehaviorTest()
        {
            ListCharactersWithLink listCharacters = new ListCharactersWithLink();
            listCharacters.ListCharacters = new Character[] { new Character(), new Character(), new Character(), new Character() };
            StackPanel stkPnl = (listCharacters as UserControl).Content as StackPanel;
            if (stkPnl != null)
            {
                Assert.IsTrue(stkPnl.Children.Count == 4);
            }
        }
    }
}
