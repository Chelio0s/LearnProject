using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LearnProject.Data
{
    public interface IRepository
    {
        /// <summary>
        /// Метод выбора коллекции сущностей по указнному условию предиката
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> GetEntities<T>(Func<T, bool> predicate) where T : class;

        /// <summary>
        /// Метод выбора коллекции сущностей
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <returns></returns>
        List<T> GetEntities<T>() where T : class;

        /// <summary>
        /// Удалить элемент из репо
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool DeleteEntity<T>(T item) where T : class;

        /// <summary>
        /// Метод добавления сущности в БД
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Объект сущности</param>
        EntityEntry<T> AddEntity<T>(T entity) where T : class;

        /// <summary>
        /// Обновление сущности в базе
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity<T>(T entity) where T : class;
    }
}
