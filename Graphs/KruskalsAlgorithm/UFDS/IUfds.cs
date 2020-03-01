namespace KruskalsAlgorithm.UFDS
{
    public interface IUfds<in T>
    {
        /// <summary>
        /// Объединить два подмножества, принадлежащих представителям
        /// </summary>
        /// <remarks>
        /// Первый представитель после объединения назначается
        /// представителем нового подмножества
        /// </remarks>
        /// <param name="itemA"> Представитель первого подмножества </param>
        /// <param name="itemB"> Представитель второго подмножества </param>
        void Union(T itemA, T itemB);
        
        /// <summary>
        /// Определяет подмножество, к которому принадлежит элемент
        /// </summary>
        /// <returns>
        /// Представитель определённого подмножества
        /// </returns>
        int Find(T item);
        
        /// <summary>
        /// Создать новое подмножество для элемента
        /// </summary>
        /// <remarks>
        /// Элемент назначается представителем созданного подмножества
        /// </remarks>
        void MakeSet(T item);
    }
}