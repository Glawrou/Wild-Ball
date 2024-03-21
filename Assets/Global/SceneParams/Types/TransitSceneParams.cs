public class TransitSceneParams : SceneParams
{
    public SceneParams NextScene { get; private set; }

    private const string Name = "Transit";

    public TransitSceneParams(SceneParams sceneParams) : base(Name)
    {
        NextScene = sceneParams;
    }
}
