using System;
using Xunit;

namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    {

        [Fact]
        [Trait("Category", "Enemy")]
        public void CreatedNormalEnemyByDefault()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act
            Enemy enemy = enemyFactory.Create("Zombie");

            //Assert
            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        [Trait("Category", "Enemy")]
        public void CreatedEnemyShouldNotBeABoss()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act
            Enemy enemy = enemyFactory.Create("Gobling");

            //Assert
            Assert.IsNotType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act
            Enemy enemy = enemyFactory.Create("Boss Gobling", true);

            //Assert
            Assert.IsType<BossEnemy>(enemy);
        }


        [Fact]
        public void CreateBossEnemyUsingAssertCast()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();
            String bossName = "King Killer Bee";

            //act
            Enemy enemy = enemyFactory.Create(bossName, true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            //Additional Assert
            Assert.Equal(bossName, boss.Name);
        }


        [Fact]
        public void CreateBossEnemy_AssertAsignableType()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act
            Enemy enemy = enemyFactory.Create("Boss Gobling", true);

            //Assert by heritance 
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemy_AssertAsignableType()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act
            Enemy enemy = enemyFactory.Create("Gobling", false);

            //Assert by heritance 
            Assert.IsAssignableFrom<Enemy>(enemy);
        }


        [Fact]
        public void CreateInstances()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act
            Enemy enemy1 = enemyFactory.Create("Gobling");
            Enemy enemy2 = enemyFactory.Create("Gobling", false);
            //Assert by type
            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotNullName()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act

            //Assert using empty lambda expresion
            Assert.Throws<ArgumentNullException>(() => enemyFactory.Create(""));
        }


        [Fact]
        public void NotNullNamewithExpecifiedParameter()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act

            //Assert using empty lambda expresion
            Assert.Throws<ArgumentNullException>("name", () => enemyFactory.Create(""));
        }

        [Fact]
        public void OnlyBossessEnemys()
        {
            //Arange
            EnemyFactory enemyFactory = new EnemyFactory();

            //act

            //Assert using empty lambda expresion
            Assert.Throws<EnemyCreationException>(() => enemyFactory.Create("Zombie", true));
        }

    }
}
