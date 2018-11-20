using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationStepper : MonoBehaviour
{
    [Range(0, 1)]
    public float initStartPoint;

    public List<UnityEngine.Events.UnityEvent> AnimationEvents = 
        new List<UnityEngine.Events.UnityEvent>();

    private float _animTimeValue;
    public float animTimeValue
    {
        get { return _animTimeValue; }

        set
        {
            float lastValue = animTimeValue;
            _animTimeValue = value;
            _animTimeValue = Mathf.Clamp01(_animTimeValue);

            foreach(AnimationEvent animEvent in animationState.clip.events)
            {
                if ((lastValue >= animEvent.time && _animTimeValue <= animEvent.time) ||
                        (lastValue <= animEvent.time && _animTimeValue >= animEvent.time))
                    FireAnimationEvent(animEvent.intParameter);
            }

            animationState.time = (_animTimeValue * animLength);
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

        animTimeValue = initStartPoint;
    }

    public void ScrubAnimation(float speed)
    {
        animTimeValue += speed * Time.deltaTime;
    }

    public void FireAnimationEvent(int index)
    {
        AnimationEvents[index].Invoke();
    }
}