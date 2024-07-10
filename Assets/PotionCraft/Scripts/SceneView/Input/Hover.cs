namespace PotionCraft.SceneView.Input
{
    public class Hover
    {
        private IHoverable _lastHover;

        public void HandleHover(IHoverable hoverable)
        {
            if(hoverable != _lastHover)
            {
                _lastHover?.HoverExit();
                _lastHover = hoverable;
                hoverable?.HoverEnter();
            }
        }
    }
}