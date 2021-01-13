using GameEngine;

namespace Mario.Characters
{
    public class KoopaTroopa : DefaultEntity

    {
        /**\brief Konstruktor obiektu KoopaTroopa korzystający z klasy DefaultEntity z solucji GameEngine
         */
        public KoopaTroopa(GameObject gameObject):base(gameObject, "koopatroopa", -10)
        {
            this.EntitySpriteSheet.DefineFrames(Direction.RIGHT, new int[] { 0, 1 });
            this.EntitySpriteSheet.DefineFrames(Direction.LEFT, new int[] { 0, 1 });
            this.EntitySpriteSheet.DefineFrames(Direction.JUMPRIGHT, new int[] { 0 });
            this.EntitySpriteSheet.DefineFrames(Direction.JUMPLEFT, new int[] { 0 });
        }
        /**Funkcja odpowiadająca za kolizję z graczem
        * @param e obiekt gracza
        * @param d kierunek poruszania się
            */
        public override void OnCharacterCollision(Entity e, Direction d)
        {
            base.OnCharacterCollision(e, d);

            if (e.GetType() == typeof(Mario) && e.Y < this.Y)
            {
                e.IsJumping = true;
                e.Velocity = -45;
                ((MainScene)gameObject.SceneManager.CurrentScene).IncreaseScore(500);
            }
        }
    }
}
