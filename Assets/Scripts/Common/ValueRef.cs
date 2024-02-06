using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ValueRef<T>
{
	public T value;

	public ValueRef() { }
	public ValueRef(T value) { this.value = value; }

	public static implicit operator T(ValueRef<T> r) { return r.value; }
}
