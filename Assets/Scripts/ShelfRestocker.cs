using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShelfRestocker : MonoBehaviour
{
    [Header("Настройки спавна")]
    [SerializeField] private GameObject _boxPrefab; // Префаб куба (коробки)
    [SerializeField] private Transform[] _spawnPoints; // 3 точки на полке, где появятся коробки

    [Header("Кнопки")]
    [SerializeField] private Button _restockButton; // Кнопка «Пополнить полки»
    [SerializeField] private Button _stopButton;    // Кнопка «Стоп»

    private Coroutine _restockRoutine; // Ссылка на запущенный процесс

    private void OnEnable()
    {
        _restockButton.onClick.AddListener(StartRestock);
        _stopButton.onClick.AddListener(StopRestock);
    }

    private void OnDisable()
    {
        _restockButton.onClick.RemoveListener(StartRestock);
        _stopButton.onClick.RemoveListener(StopRestock);
    }

    private void StartRestock()
    {
        // Пункт 2: Если процесс уже идёт — игнорируем повторное нажатие
        if (_restockRoutine != null) return;

        _restockRoutine = StartCoroutine(RestockCoroutine());
    }

    private void StopRestock()
    {
        // Пункт 3: Если процесс идёт — обрываем его в любую паузу
        if (_restockRoutine != null)
        {
            StopCoroutine(_restockRoutine);
            _restockRoutine = null; // Сбрасываем ссылку, чтобы можно было запустить заново
            Debug.Log("Пополнение остановлено!");
        }
    }

    private IEnumerator RestockCoroutine()
    {
        // Пункт 1: Ждём 2 секунды -> спавним первую коробку
        yield return new WaitForSeconds(2f);
        SpawnBox(0);

        // Ждём ещё 1 секунду (итого 3 с) -> спавним вторую коробку
        yield return new WaitForSeconds(1f);
        SpawnBox(1);

        // Ждём ещё 0.5 секунды (итого 3.5 с) -> спавним третью коробку
        yield return new WaitForSeconds(0.5f);
        SpawnBox(2);

        // Пополнение закончилось, очищаем переменную, чтобы кнопку снова можно было нажать
        _restockRoutine = null;
    }

    private void SpawnBox(int index)
    {
        // Защита, чтобы не вылетела ошибка, если забыл указать точки
        if (_boxPrefab != null && index < _spawnPoints.Length && _spawnPoints[index] != null)
        {
            Instantiate(_boxPrefab, _spawnPoints[index].position, Quaternion.identity);
        }
    }
}
