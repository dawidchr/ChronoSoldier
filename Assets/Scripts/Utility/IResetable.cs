public interface IResetable {
    // Used mostly for static variables
    void ResetScriptOnSceneLoad();
    void ResetScriptInSceneAction();
}
