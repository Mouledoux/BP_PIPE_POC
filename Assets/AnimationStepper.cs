using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationStepper : MonoBehaviour
{
    public List<UnityEngine.Events.UnityEvent> AnimationEvents = 
        new List<UnityEngine.Events.UnityEvent>();

    private float _value;

    public float value
    {
        get { return _value; }

        set
        {
            float lastValue = _value;
            _value = value;
            _value = Mathf.Clamp01(_value);

            foreach(AnimationEvent animEvent in animationState.clip.events)
            {
                if ((lastValue >= animEvent.time && _value <= animEvent.time) ||
                        (lastValue <= animEvent.time && _value >= animEvent.time))
                    FireAnimationEvent(animEvent.intParameter);
            }

            animationState.time = (_value * animLength);
        }
    }

    private new Animation animation;
    private AnimationState animationState;

    private float animLength;

    void Awake ()
    {
        animation = GetComponent<Animation>();

        animation.playAutomatically = true;

        animationState = animation[animation.clip.name];
        animationState.speed = 0;

        animLength = animationState.length;

        print(AnimationEvents.Count);
    }

    public void ScrubAnimation(bool forward)
    {
        value += Time.deltaTime * (forward ? 1f : -1f);
    }

    public void FireAnimationEvent(int index)
    {
        AnimationEvents[index].Invoke();
        print(index);
    }
}