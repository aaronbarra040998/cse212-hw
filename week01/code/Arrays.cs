using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan - MultiplesOf:
        // 1. Crear un array 'result' de tipo double con tamaño 'length'.
        // 2. Recorrer i desde 0 hasta length - 1.
        //    a. En cada iteración calcular el múltiplo: multiple = number * (i + 1).
        //    b. Asignar result[i] = multiple.
        // 3. Devolver el array result.
        // Consideraciones:
        // - Si length == 0 (aunque el enunciado dice > 0), devolver arreglo vacío.
        // - Complejidad temporal: O(length). Complejidad espacial: O(length).

        if (length <= 0)
        {
            // Seguro: devolver arreglo vacío si por alguna razón llega 0 o negativo.
            return new double[0];
        }

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            // multiplicar por (i + 1) porque el primer múltiplo es number * 1
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan - RotateListRight (usando slicing con GetRange):
        // 1. Validar que data no sea nulo y que data.Count > 0.
        // 2. Calcular splitIndex = data.Count - amount. (Si amount == data.Count, splitIndex == 0).
        // 3. Crear sublista 'right' = data.GetRange(splitIndex, amount) -> elementos que deben quedar al frente.
        // 4. Crear sublista 'left' = data.GetRange(0, splitIndex) -> elementos que van al final.
        // 5. Vaciar la lista original (data.Clear()).
        // 6. Añadir los elementos en orden: AddRange(right); AddRange(left).
        // 7. Complejidad: O(n) tiempo y O(n) espacio (debido a las sublistas temporales). Esta solución es fácil de entender
        //    y es segura con las operaciones que List<T> provee.
        //
        // Alternativa (no implementada aquí): rotación in-place usando reverses para lograr O(1) espacio adicional.

        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int n = data.Count;
        if (n == 0)
        {
            // Nada que rotar
            return;
        }

        // Asegurarnos de que amount esté dentro del rango válido. Según el enunciado venga en 1..n,
        // pero robustecemos la función para cualquier entrada:
        amount = amount % n; // si amount == n -> 0, amount > n -> ajusta
        if (amount == 0)
        {
            // Rotación por múltiplo de n deja la lista igual.
            return;
        }

        int splitIndex = n - amount; // index desde donde tomamos la parte derecha

        // Obtener sublistas (GetRange lanza si los parámetros no son válidos, pero con splitIndex y amount están OK)
        List<int> right = data.GetRange(splitIndex, amount);
        List<int> left = data.GetRange(0, splitIndex);

        // Reconstruir la lista original con el orden rotado
        data.Clear();
        data.AddRange(right);
        data.AddRange(left);
    }
}
