using System.Reflection.PortableExecutable;
using ConsoleApp1;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebaInicial.Tests;

[TestSubject(typeof(Character))]
public class CharacterTest
{
    //test constants
    
    private const string testName = "testName";
    private static readonly Random testrandom = new Random();
    private readonly int? testMaxHitPoints = null;
    private const int testBaseDamage = 100;
    private const int testBaseArmor = 100;
    private const int testPointsHealth = 1000;
    
    //test variables
    
    private Character _character;
    private List<IItem> _testAllDamage;

    public CharacterTest()
    {
        // every test method generates a new CharacterTest object.
        //_character = new Character(testName, testMaxHitPoints, testBaseDamage, testBaseArmor, testPointsHealth);
      
    }
    
   
    public void NameTest()
    {
        // test character name
        Assert.Equals(testName, _character.Name);
    }
 
    public void HpTest()
    {
        // test maxhp
        Assert.Equals(testMaxHitPoints, _character.MaxHitPoints);
        
        Assert.Equals(testPointsHealth, _character.PointsHealth);
    }

    public void InventoryTest()
    {
        Assert.Equals(testBaseArmor, _character.BaseArmor);
        Assert.Equals(testBaseDamage, _character.BaseDamage);
        // test inventory
        //Assert.Equals(_character.BaseDamage + , _character.Attack());
        //Assert.Equals(Shield.DefaultArmor + Helmet.DefaultArmor + _character.BaseArmor, _character.Defense());
        //var newItem = new Axe();
        //_character.AddItem(newItem);
        //Assert.Equals(56, _character.InventoryCount());
        //Assert.Equals(Axe.DefaultDamage*2 + Sword.DefaultDamage + _character.BaseDamage, _character.Attack());
        //_character.RemoveItem(newItem);
        //Assert.Equals(4, _character.InventoryCount());
        //Assert.Equals(Axe.DefaultDamage + Sword.DefaultDamage + _character.BaseDamage, _character.Attack());
        //Assert.Equals(Shield.DefaultArmor*2 + Helmet.DefaultArmor + _character.BaseArmor, _character.Defense());
    }
    
   
    public void HealthTest()
    {
        // test heal/receive damage
       // _character.ReceiveDamage(5);
        //Assert.Equal(5, _character.HitPoints);
        _character.Heal(10);
        //Assert.Equal(10, _character.HitPoints);
    }

   
}
