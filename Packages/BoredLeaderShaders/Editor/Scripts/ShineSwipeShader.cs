using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShaderEffects
{

    //@Divesh Functionality of ShaderShine.Shader
    [RequireComponent(typeof(Image))]
    public class ShineSwipeShader : MonoBehaviour
    {
        //@Divesh Reference to sprite Data
        [Header("Sprite Material")]
        public Material spriteMaterial = null;
        private Image _spriteRenderer;

        //@Divesh Reference to shader effect values
        [Header("Shader Settings")]
        [SerializeField]
        private float _defaultShinePos = 1;
        private int _shineLocationParameterID;
        [SerializeField]
        private float _shineSpeed = 1f;
        [SerializeField]
        private bool _isLoop = true;
        [SerializeField]
        private float _delay = 2.5f;

        private float _currentShinePos;

        void Start()
        {
            //@Divesh - get the shine location property from shader
            _shineLocationParameterID = Shader.PropertyToID("_ShineLocation");

            //@Divesh - get the material from sprite
            _spriteRenderer = GetComponent<Image>();
            spriteMaterial = _spriteRenderer.material;
            StartShineCoroutine(_defaultShinePos, _shineSpeed, _isLoop, _delay);
        }

        public void StartShineCoroutine(float startShinePos, float shineSpeed, bool isLoop, float delay)
        {
            StartCoroutine(ShineCoroutine(startShinePos, shineSpeed, isLoop, delay));
        }

        private IEnumerator ShineCoroutine(float _startShinePos, float _shineSpeed, bool isLoop, float Delay)
        {
            //@Divesh - Repeat this routine if Loop is true
            if (_isLoop)
            {
                _currentShinePos = _defaultShinePos;
                //@Divesh - delay time before animaton
                yield return new WaitForSeconds(_delay);
                //@Divesh - Set current time and check how much time has passed since this frame
                float startTime = Time.time;
                while (Time.time < startTime + 1.5f)
                {
                    //@Divesh - change shader value 
                    _currentShinePos = _currentShinePos + _shineSpeed * Time.deltaTime;
                    spriteMaterial.SetFloat(_shineLocationParameterID, _currentShinePos);

                    yield return new WaitForEndOfFrame();
                }
                //@Divesh - reset shader value 
                _currentShinePos = _defaultShinePos;
                StartCoroutine(ShineCoroutine(_defaultShinePos, _shineSpeed, isLoop, _delay));
            }
            else
            {
                //@Divesh - change shader value 
                yield return new WaitForSeconds(_delay);
                _defaultShinePos = _defaultShinePos - _shineSpeed * Time.deltaTime;
                spriteMaterial.SetFloat(_shineLocationParameterID, _defaultShinePos);
                yield return new WaitForEndOfFrame();
                //@Divesh - stop shader animation 
                StopCoroutine(ShineCoroutine(_defaultShinePos, _shineSpeed, isLoop, _delay));
            }
            yield break;
        }
    }
}