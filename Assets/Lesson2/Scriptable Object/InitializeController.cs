namespace HorrorGame
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, FlyingCubeData flyingCubeDataOne, 
            FlyingCubeData flyingCubeDataTwo)
        {
            new FlyingCubeInitializator(mainController, flyingCubeDataOne);
            new FlyingCubeInitializator(mainController, flyingCubeDataTwo);
        }
    }
}
