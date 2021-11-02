using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class SecondScrollRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public ScrollRect OtherScrollRect;
    private ScrollRect _myScrollRect;
    //This tracks if the other one should be scrolling instead of the current one.
    private bool scrollOther;
    //This tracks wether the other one should scroll horizontally or vertically.
    private bool scrollOtherHorizontally;

    [SerializeField] bool autoInit;

    private void Awake()
    {
        _myScrollRect = GetComponent<ScrollRect>();

        if (autoInit && OtherScrollRect)
            Init(OtherScrollRect);
    }

    private void OnEnable()
    {
        if (_myScrollRect)
        {
           if(_myScrollRect.vertical) _myScrollRect.normalizedPosition = new Vector2(_myScrollRect.normalizedPosition.x, 1f);
           else
                _myScrollRect.normalizedPosition = new Vector2(1f, _myScrollRect.normalizedPosition.y);
        }
    }

    public void Init()
    {
        if (autoInit && OtherScrollRect)
            Init(OtherScrollRect);
    }

    public void Init(ScrollRect OtherScrollRect)
    {
        this.OtherScrollRect = OtherScrollRect;

        if (OtherScrollRect == null) return;

        enabled = true;

        //Get the current scroll rect so we can disable it if the other one is scrolling
        _myScrollRect = GetComponent<ScrollRect>();
        //If the current scroll Rect has the vertical checked then the other one will be scrolling horizontally.
        scrollOtherHorizontally = _myScrollRect.vertical;
        //Check some attributes to let the user know if this wont work as expected
        if (scrollOtherHorizontally)
        {
            if (_myScrollRect.horizontal)
                Debug.Log("You have added the SecondScrollRect to a scroll view that already has both directions selected");
            if (!OtherScrollRect.horizontal)
                Debug.Log("The other scroll rect doesnt support scrolling horizontally");
        }
        else if (!OtherScrollRect.vertical)
        {
            Debug.Log("The other scroll rect doesnt support scrolling vertically");
        }
    }
    //IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Get the absolute values of the x and y differences so we can see which one is bigger and scroll the other scroll rect accordingly
        float horizontal = Mathf.Abs(eventData.position.x - eventData.pressPosition.x);
        float vertical = Mathf.Abs(eventData.position.y - eventData.pressPosition.y);
        if (scrollOtherHorizontally)
        {
            if (horizontal > vertical)
            {
                scrollOther = true;
                //disable the current scroll rect so it doesnt move.
                _myScrollRect.enabled = false;
                OtherScrollRect.OnBeginDrag(eventData);
            }
        }
        else if (vertical > horizontal)
        {
            scrollOther = true;
            //disable the current scroll rect so it doesnt move.
            _myScrollRect.enabled = false;
            OtherScrollRect.OnBeginDrag(eventData);
        }
    }
    //IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        if (scrollOther)
        {
            scrollOther = false;
            _myScrollRect.enabled = true;
            OtherScrollRect.OnEndDrag(eventData);
        }
    }
    //IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        if (scrollOther)
        {
            OtherScrollRect.OnDrag(eventData);
        }
    }
}
