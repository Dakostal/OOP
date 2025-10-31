// Animal.cs
using System;

namespace AnimalsProgram;

public class Animal
{
    private string _name;
    private int _age;
    private int _limbs;
    private AnimalType _type;
    private Habitat _habitat;
    private Continent _continent;
    private bool _hasTail;

    public int Age
    {
        set => _age = value >= 0 ? value : 0;
    }

    public string Name => _name;

    public Animal()
    {
        _name = "Безымянное";
        _age = 0;
        _limbs = 4;
        _type = AnimalType.Herbivore;
        _habitat = Habitat.Land;
        _continent = Continent.Europe;
        _hasTail = true;
    }

    public Animal(string name, int age, int limbs, AnimalType type, Habitat habitat, Continent continent, bool hasTail)
    {
        _name = name;
        _age = age >= 0 ? age : 0;
        _limbs = limbs >= 0 ? limbs : 0;
        _type = type;
        _habitat = habitat;
        _continent = continent;
        _hasTail = hasTail;
    }

    public static bool operator ==(Animal? a1, Animal? a2)
    {
        if (ReferenceEquals(a1, a2)) return true;
        if (a1 is null || a2 is null) return false;
        return a1._name == a2._name && a1._age == a2._age && a1._type == a2._type &&
               a1._habitat == a2._habitat && a1._continent == a2._continent;
    }

    public static bool operator !=(Animal? a1, Animal? a2) => !(a1 == a2);

    public virtual string GetSound() => "...";
    public virtual bool CanFly() => _habitat == Habitat.Air;
    public virtual bool CanSwim() => _habitat == Habitat.Water || _habitat == Habitat.Amphibious;
    public bool ExistsTail() => _hasTail;

    public override bool Equals(object? obj) => obj is Animal other && this == other;
    public override int GetHashCode() => HashCode.Combine(_name, _age, _type, _habitat, _continent);

    public override string ToString() =>
        $"Животное: {_name}, Возраст: {_age}, Конечностей: {_limbs}, " +
        $"Тип: {_type}, Среда: {_habitat}, Континент: {_continent}, Хвост: {(_hasTail ? "есть" : "нет")}";
}