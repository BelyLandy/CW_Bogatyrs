using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using FreeDraw;

public class RecognitionManager : MonoBehaviour
{
    [SerializeField] private Drawable _drawable;
    [SerializeField] private TextMeshProUGUI _recognitionResult;
    [SerializeField] private Button _templateModeButton;
    [SerializeField] private Button _recognitionModeButton;
    [SerializeField] private Button _reviewTemplates;
    [SerializeField] private TMP_InputField _templateName;
    [SerializeField] private TemplateReviewPanel _templateReviewPanel;
    [SerializeField] private RecognitionPanel _recognitionPanel;

    public RecognizedShape lastRecognizedShape = RecognizedShape.Unrecognized;
    
    private GestureTemplates _templates => GestureTemplates.Get();
    private static readonly DollarOneRecognizer _dollarOneRecognizer = new DollarOneRecognizer();
    private IRecognizer _currentRecognizer = _dollarOneRecognizer;
    private RecognizerState _state = RecognizerState.RECOGNITION;

    //public Gesture _currGesture;
    
    public enum RecognizerState
    {
        TEMPLATE,
        RECOGNITION,
        TEMPLATE_REVIEW
    }

    [Serializable]
    public struct GestureTemplate
    {
        public string Name;
        public DollarPoint[] Points;

        public GestureTemplate(string templateName, DollarPoint[] preparePoints)
        {
            Name = templateName;
            Points = preparePoints;
        }
    }

    private string TemplateName => _templateName.text;


    private void Start()
    {
        _drawable.OnDrawFinished += OnDrawFinished;
        _templateModeButton.onClick.AddListener(() => SetupState(RecognizerState.TEMPLATE));
        _recognitionModeButton.onClick.AddListener(() => SetupState(RecognizerState.RECOGNITION));
        _reviewTemplates.onClick.AddListener(() => SetupState(RecognizerState.TEMPLATE_REVIEW));
        _recognitionPanel.Initialize(SwitchRecognitionAlgorithm);

        SetupState(_state);
    }

    private void SwitchRecognitionAlgorithm(int algorithm)
    {
        if (algorithm == 0)
        {
            _currentRecognizer = _dollarOneRecognizer;
        }
    }

    private void SetupState(RecognizerState state)
    {
        _state = state;
        _templateModeButton.image.color = _state == RecognizerState.TEMPLATE ? Color.green : Color.white;
        _recognitionModeButton.image.color = _state == RecognizerState.RECOGNITION ? Color.green : Color.white;
        _reviewTemplates.image.color = _state == RecognizerState.TEMPLATE_REVIEW ? Color.green : Color.white;
        _templateName.gameObject.SetActive(_state == RecognizerState.TEMPLATE);
        _recognitionResult.gameObject.SetActive(_state == RecognizerState.RECOGNITION);

        //_drawable.gameObject.SetActive(state != RecognizerState.TEMPLATE_REVIEW);
        _templateReviewPanel.SetVisibility(state == RecognizerState.TEMPLATE_REVIEW);
        _recognitionPanel.SetVisibility(state == RecognizerState.RECOGNITION);
    }

    private Vector2 GetGestureCenter(DollarPoint[] points)
    {
        float sumX = 0f;
        float sumY = 0f;
        foreach (var pt in points)
        {
            sumX += pt.Point.x;
            sumY += pt.Point.y;
        }
        return new Vector2(sumX / points.Length, sumY / points.Length);
    }
    
    private void OnDrawFinished(DollarPoint[] points)
    {
        if (_state == RecognizerState.TEMPLATE)
        {
            GestureTemplate preparedTemplate =
                new GestureTemplate(TemplateName, _currentRecognizer.Normalize(points, 64));
            _templates.RawTemplates.Add(new GestureTemplate(TemplateName, points));
            _templates.ProceedTemplates.Add(preparedTemplate);
        }
        else
        {
            (string recognizedName, float score) result = _currentRecognizer.DoRecognition(
                points, 
                64,
                _templates.RawTemplates
            );
            
            string resultText = $"Recognized: {result.recognizedName}, Score: {result.score}";
            _recognitionResult.text = resultText;
            Debug.Log(resultText);

            // Приведение строки результата к enum
            lastRecognizedShape = Enum.TryParse(result.recognizedName, out RecognizedShape shape)
                ? shape : RecognizedShape.Unrecognized;

            // Если распознанный жест достаточно точный (score >= порогового значения)
            if (result.score >= 0.7f)
            {
                // Вычисляем центр жеста (в пикселях)
                Vector2 gestureCenterPixels = GetGestureCenter(points);

                // Если у вас нет метода обратного преобразования, добавьте его в Drawable (см. ниже)
                Vector2 gestureWorldPos = _drawable.PixelToWorldCoordinates(gestureCenterPixels);

                // Передаём мировую точку в ZoneManager для проверки зон
                ZoneManager.Instance.CheckZones(gestureWorldPos, result.recognizedName);
            }
        }
    }

    private void OnApplicationQuit()
    {
        _templates.Save();
    }
}