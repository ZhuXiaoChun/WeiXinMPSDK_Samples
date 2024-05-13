/*----------------------------------------------------------------
    Copyright (C) 2024 Senparc
    
    文件名：CustomMessageContext.cs
    文件功能描述：微信消息上下文
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

//DPBMARK_FILE MP
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.MessageContexts;

namespace Senparc.Weixin.Sample.MP;

/* v16.8.0 后，提供分布式缓存，只需要直接使用 DefaultMpMessageContext，即使没有 CustomMessageContext 也没有关系 */
public class CustomMessageContext : DefaultMpMessageContext  //MessageContext<IRequestMessageBase, IResponseMessageBase>
{
	public CustomMessageContext()
	{
#pragma warning disable CS8622 // 参数类型中引用类型的为 Null 性与目标委托不匹配(可能是由于为 Null 性特性)。
		base.MessageContextRemoved += DidCustomMessageContext_MessageContextRemoved;
#pragma warning restore CS8622 // 参数类型中引用类型的为 Null 性与目标委托不匹配(可能是由于为 Null 性特性)。
	}

	/// <summary>
	/// 当上下文过期，被移除时触发的时间
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="eventArgs"></param>
	void DidCustomMessageContext_MessageContextRemoved(
		object sender,
		Senparc.NeuChar.Context.WeixinContextRemovedEventArgs
		<IRequestMessageBase, IResponseMessageBase> eventArgs)
	{
		/* 注意，这个事件不是实时触发的（当然你也可以专门写一个线程监控）
		 * 为了提高效率，根据WeixinContext中的算法，这里的过期消息会在过期后下一条请求执行之前被清除
		 */
		if (eventArgs.MessageContext is not CustomMessageContext messageContext)
		{
			return;//如果是正常的调用，messageContext不会为null
		}

		//TODO:这里根据需要执行消息过期时候的逻辑，下面的代码仅供参考

		//Log.InfoFormat("{0}的消息上下文已过期",eventArgs.OpenId);
		//api.SendMessage(eventArgs.OpenId, "由于长时间未搭理客服，您的客服状态已退出！");
	}
}
