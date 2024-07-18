namespace Models
{
    public abstract class Manager : Any
    {
        /// <summary>
        /// Заполняет пустое пространство новыми элементами
        /// </summary>
        /// <precondition>На доске есть пустые элементы</precondition>
        /// <postcondition>Доска заполнилась новыми элементами и пустоты отсутствуют</postcondtion>
        public abstract void GenerateTiles();

        /// <summary>
        /// Удаляет сматченные компоненты
        /// </summary>
        /// <precondition>Элементы выстроились 3 в ряд и более</precondition>
        /// <postcondition>С игрового поля удалены выстроенные элементы</postcondtion>
        public abstract void DeleteMatched();
    }
}