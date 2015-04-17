<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plugin-friend.ascx.cs" Inherits="Presentation.modules.plugin_friend" %>
<div class="chat-panel panel panel-danger">
    <div class="panel-heading">
        Danh sách bạn
    </div>
    <div class="panel-footer">
        <div class="input-group">
            <input id="Text1" type="text" class="form-control input-sm" placeholder="Tìm kiếm" />
            <span class="input-group-btn">
                <button class="btn btn-warning btn-sm" id="Button1">
                    Tìm kiếm
                </button>
            </span>
        </div>
    </div>
    <div class="panel-body">
        <ul class="chat">
            <li class="left clearfix">
                <span class="chat-img pull-left">
                    <img src="../img/unnamed.png" alt="User Avatar" class="img-circle" />
                </span>
                <div class="chat-body clearfix">
                    <div class="header">New User 1</div>
                </div>
            </li>
            <li class="left clearfix">
                <span class="chat-img pull-left">
                    <img src="../img/unnamed.png" alt="User Avatar" class="img-circle" />
                </span>
                <div class="chat-body clearfix">
                    <div class="header">New User 1</div>
                </div>
            </li>
        </ul>
        <div class="clearfix"></div>
    </div>
</div>