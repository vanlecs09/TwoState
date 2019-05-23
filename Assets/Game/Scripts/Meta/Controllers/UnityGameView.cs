using UnityEngine;
using Entitas;
public class UnityGameView : MonoBehaviour, IViewController {

    protected Contexts _contexts;
    protected GameEntity _entity;

    public Vector3 Position 
    {
        get {return transform.position;} 
        set {transform.position = value;}
    }

    public Vector3 Scale 
    {
        get {return transform.localScale;}
        set { transform.localScale = value;}
    }

    public bool Active {get {return gameObject.activeSelf;} set {gameObject.SetActive(value);} }

    public void InitializeView(Contexts contexts, IEntity entity) 
    {
        _contexts = contexts;
        _entity = (GameEntity)entity;
        // gameObject.Link()
    }

    public void DestroyView() {
        Object.Destroy(this);
    }
}