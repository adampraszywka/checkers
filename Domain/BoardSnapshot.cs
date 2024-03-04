using System.Collections.ObjectModel;

namespace Domain;

public class BoardSnapshot(IDictionary<int, IEnumerable<SquareSnapshot>> dictionary)
    : ReadOnlyDictionary<int, IEnumerable<SquareSnapshot>>(dictionary);