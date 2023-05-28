#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};

// PointER
struct PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283;
// System.String
struct String_t;

IL2CPP_EXTERN_C RuntimeClass* PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283_il2cpp_TypeInfo_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t1CF90E2A33B5DEB436121AEB0727CE740F1F10C1 
{
};

// PointER
struct PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283  : public RuntimeObject
{
	// System.Single PointER::x
	float ___x_0;
	// System.Single PointER::y
	float ___y_1;
	// System.Single PointER::z
	float ___z_2;
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// <Module>

// <Module>

// PointER

// PointER

// System.String
struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.String

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Boolean

// System.Int32

// System.Int32

// System.Single

// System.Single

// System.Void

// System.Void
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.String System.Single::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972 (float* __this, const RuntimeMethod* method) ;
// System.Boolean PointER::op_Equality(PointER,PointER)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PointER_op_Equality_mFDA86C22281FEA53A3F8D4BBFDD312A64CDF0B3E (PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* ___0_left, PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* ___1_right, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void PointER::.ctor(System.Single,System.Single,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PointER__ctor_m6F30D9262BE15A721D76D8D9A6D6D6E37CE81F22 (PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* __this, float ___0_x, float ___1_y, float ___2_z, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		float L_0 = ___0_x;
		__this->___x_0 = L_0;
		float L_1 = ___1_y;
		__this->___y_1 = L_1;
		float L_2 = ___2_z;
		__this->___z_2 = L_2;
		return;
	}
}
// System.Int32 PointER::GetHashCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t PointER_GetHashCode_m37954111B3F90BB550270B85E610E1E4EAFF2CF8 (PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	{
		float* L_0 = (&__this->___x_0);
		String_t* L_1;
		L_1 = Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972(L_0, NULL);
		NullCheck(L_1);
		int32_t L_2;
		L_2 = VirtualFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_1);
		V_0 = L_2;
		float* L_3 = (&__this->___y_1);
		String_t* L_4;
		L_4 = Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972(L_3, NULL);
		NullCheck(L_4);
		int32_t L_5;
		L_5 = VirtualFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_4);
		V_1 = L_5;
		float* L_6 = (&__this->___z_2);
		String_t* L_7;
		L_7 = Single_ToString_mE282EDA9CA4F7DF88432D807732837A629D04972(L_6, NULL);
		NullCheck(L_7);
		int32_t L_8;
		L_8 = VirtualFuncInvoker0< int32_t >::Invoke(2 /* System.Int32 System.Object::GetHashCode() */, L_7);
		V_2 = L_8;
		int32_t L_9 = V_0;
		int32_t L_10 = V_1;
		int32_t L_11 = V_2;
		V_3 = ((int32_t)(((int32_t)(L_9^L_10))^L_11));
		goto IL_003c;
	}

IL_003c:
	{
		int32_t L_12 = V_3;
		return L_12;
	}
}
// System.Boolean PointER::Equals(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PointER_Equals_m5A1F1D06D9205948D96EC598BE56A5C858503415 (PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* __this, RuntimeObject* ___0_obj, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		RuntimeObject* L_0 = ___0_obj;
		bool L_1;
		L_1 = PointER_op_Equality_mFDA86C22281FEA53A3F8D4BBFDD312A64CDF0B3E(__this, ((PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283*)CastclassClass((RuntimeObject*)L_0, PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283_il2cpp_TypeInfo_var)), NULL);
		V_0 = L_1;
		goto IL_0010;
	}

IL_0010:
	{
		bool L_2 = V_0;
		return L_2;
	}
}
// System.Boolean PointER::op_Equality(PointER,PointER)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PointER_op_Equality_mFDA86C22281FEA53A3F8D4BBFDD312A64CDF0B3E (PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* ___0_left, PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* ___1_right, const RuntimeMethod* method) 
{
	bool V_0 = false;
	bool V_1 = false;
	int32_t G_B5_0 = 0;
	{
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_0 = ___0_left;
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_1 = ___1_right;
		V_1 = (bool)((((int32_t)((((RuntimeObject*)(PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283*)L_0) == ((RuntimeObject*)(PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283*)L_1))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		bool L_2 = V_1;
		if (L_2)
		{
			goto IL_0011;
		}
	}
	{
		V_0 = (bool)1;
		goto IL_0057;
	}

IL_0011:
	{
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_3 = ___0_left;
		if (!L_3)
		{
			goto IL_001d;
		}
	}
	{
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_4 = ___1_right;
		G_B5_0 = ((((int32_t)((((RuntimeObject*)(PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283*)L_4) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0)) == ((int32_t)0))? 1 : 0);
		goto IL_001e;
	}

IL_001d:
	{
		G_B5_0 = 0;
	}

IL_001e:
	{
		V_1 = (bool)G_B5_0;
		bool L_5 = V_1;
		if (L_5)
		{
			goto IL_0027;
		}
	}
	{
		V_0 = (bool)0;
		goto IL_0057;
	}

IL_0027:
	{
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_6 = ___0_left;
		NullCheck(L_6);
		float L_7 = L_6->___x_0;
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_8 = ___1_right;
		NullCheck(L_8);
		float L_9 = L_8->___x_0;
		V_1 = (bool)((((float)L_7) == ((float)L_9))? 1 : 0);
		bool L_10 = V_1;
		if (L_10)
		{
			goto IL_003d;
		}
	}
	{
		V_0 = (bool)0;
		goto IL_0057;
	}

IL_003d:
	{
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_11 = ___0_left;
		NullCheck(L_11);
		float L_12 = L_11->___y_1;
		PointER_tC925B28B0C638C06378D4E50963A7EAA651D2283* L_13 = ___1_right;
		NullCheck(L_13);
		float L_14 = L_13->___y_1;
		V_1 = (bool)((((float)L_12) == ((float)L_14))? 1 : 0);
		bool L_15 = V_1;
		if (L_15)
		{
			goto IL_0053;
		}
	}
	{
		V_0 = (bool)0;
		goto IL_0057;
	}

IL_0053:
	{
		V_0 = (bool)1;
		goto IL_0057;
	}

IL_0057:
	{
		bool L_16 = V_0;
		return L_16;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
