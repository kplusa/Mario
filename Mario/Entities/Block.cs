using GameEngine;
namespace Mario.Characters
    
{     public class Block : DefaultEntity
    {
        /**\brief Konstruktor obiektu Block korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public Block(GameObject gameObject): base(gameObject,"block")
        {
            this.GetEntitySpriteSheet().DefineFrames(Direction.NONE, new int[] { 0 });
        }
    }
}
