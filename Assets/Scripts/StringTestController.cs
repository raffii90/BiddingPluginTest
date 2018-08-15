using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class StringTestController : MonoBehaviour {
    [SerializeField] private Button _concatButton;
    [SerializeField] private Button _removeButton;
    [SerializeField] private Button _reverseButton;
    [SerializeField] private InputField _concatFirstStr;
    [SerializeField] private InputField _concatSecondStr;
    [SerializeField] private InputField _removeStr;
    [SerializeField] private InputField _numberOfRemovedCaracters;
    [SerializeField] private InputField _reverseStr;

    private void Concat() {
        Debug.LogError(
            Marshal.PtrToStringAnsi(
                StringTestImport.GetConcatenatedString(_concatFirstStr.text, _concatSecondStr.text)));
    }

    private void Remove() {
        Debug.LogError(Marshal.PtrToStringAnsi(
            StringTestImport.RemoveCharsFromEnd(_removeStr.text, Int32.Parse(_numberOfRemovedCaracters.text))));
    }

    private void Reverse() {
        Debug.LogError(Marshal.PtrToStringAnsi(StringTestImport.ReverseString(_reverseStr.text)));
    }

    private void Start() {
        _concatButton.onClick.AddListener(Concat);
        _removeButton.onClick.AddListener(Remove);
        _reverseButton.onClick.AddListener(Reverse);
    }
}